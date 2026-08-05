const inlineDefsAndRemoveMasks = {
    name: 'inlineDefsAndRemoveMasks',
    fn: () => {
        /** @type {Map<string, object>} id -> referenced node */
        const defsById = new Map();

        const href = (node) =>
            node.attributes['xlink:href'] ?? node.attributes.href;

        return {
            element: {
                // First pass on the way down: collect id-addressable nodes inside <defs>.
                enter: (node) => {
                    if (node.name === 'defs') {
                        for (const child of node.children) {
                            const id = child.attributes?.id;
                            if (id) {
                                defsById.set(id, child);
                            }
                        }
                    }
                },
                // On the way up the tree is fully populated, so we can rewrite.
                exit: (node, parentNode) => {
                    // Drop masks entirely (self-masks in this export are useless).
                    if (node.name === 'mask') {
                        parentNode.children = parentNode.children.filter(
                            (child) => child !== node,
                        );
                        return;
                    }

                    // Replace <use> that references a collected def with the def itself.
                    if (node.name === 'use') {
                        const ref = href(node);
                        const id = ref?.startsWith('#') ? ref.slice(1) : undefined;
                        const target = id ? defsById.get(id) : undefined;

                        if (!target) {
                            return;
                        }

                        const inlined = structuredClone(target);

                        // Carry over presentation attributes from the <use>,
                        // but drop the reference/id plumbing.
                        for (const [key, value] of Object.entries(node.attributes)) {
                            if (key === 'xlink:href' || key === 'href') {
                                continue;
                            }
                            inlined.attributes[key] = value;
                        }
                        delete inlined.attributes.id;

                        const index = parentNode.children.indexOf(node);
                        parentNode.children.splice(index, 1, inlined);
                        return;
                    }

                    // Remove <defs> once its children have been inlined elsewhere.
                    if (node.name === 'defs') {
                        parentNode.children = parentNode.children.filter(
                            (child) => child !== node,
                        );
                    }
                },
            },
        };
    },
};

export default {
    // Multipass required: the custom inlineDefsAndRemoveMasks plugin runs AFTER
    // preset-default, so paths introduced by inlining need another pass through
    // convertPathData to reach a stable (idempotent) result. Without this a single
    // SVGO run is not a fixed point and VerifySvgoIdempotency fails by a few bytes.
    multipass: true, // boolean
    js2svg: {
        indent: 4, // number
        // SVGOMG: Prettify disabled -> minified single-line output (Should_be_minified test)
        pretty: false, // boolean
    },
    plugins: [
        {
            name: 'preset-default', // built-in plugins enabled by default
            params: {
                // SVGOMG: Number precision 3 (applies to convertPathData/convertTransform).
                // Transform precision 5 is the SVGO default (transformPrecision) -> no override.
                floatPrecision: 3,
                // Note: In SVGO v4 removeViewBox is NOT part of preset-default anymore,
                // so the viewBox is preserved by default (no override needed / allowed).
                // Together with NOT enabling removeDimensions this keeps viewBox + width + height,
                // which is required because the icons are used in two ways:
                //   1) GetSvgMarkup() -> raw SVG embedded standalone (needs width/height)
                //   2) MonochromeIcon.razor -> CSS mask-image on a 32x32 ::before
                // cleanupNumericValues stays enabled (SVGO default) so the "px" unit is
                // stripped from width/height (user unit == px per SVG 1.1 7.4).
            },
        },

        // Resolve Sketch's <defs>/<mask>/<use> pattern into inlined elements
        // before ids are cleaned up.
        inlineDefsAndRemoveMasks,

        // Remove namespace declarations left unused after inlining (e.g. xlink),
        // since multipass is disabled and preset-default ran before the inline step.
        'removeUnusedNS',

        // Remove <title> elements (not part of preset-default).
        'removeTitle',

        // Match existing behavior: remove fill/stroke/version attributes
        {
            name: 'removeAttrs',
            params: {
                attrs: ['fill', 'stroke', 'version'],
            },
        },
    ],
};
