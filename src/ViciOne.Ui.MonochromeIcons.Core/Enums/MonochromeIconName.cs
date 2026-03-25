using System;

namespace ViciOne.Ui.MonochromeIcons.Core.Enums;

/// <summary>
/// Defines icon names for the Monochrome Icon set.
/// </summary>
public readonly record struct MonochromeIconName : ITypeSafeEnumImplementation<MonochromeIconName>
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static readonly MonochromeIconName Add = new(nameof(Add));
    public static readonly MonochromeIconName AddTextLabelsSolid = new(nameof(AddTextLabelsSolid));
    public static readonly MonochromeIconName AddUser = new(nameof(AddUser));
    public static readonly MonochromeIconName AlarmLight = new(nameof(AlarmLight));
    public static readonly MonochromeIconName AlarmSolid = new(nameof(AlarmSolid));
    public static readonly MonochromeIconName AlignBottom = new(nameof(AlignBottom));
    public static readonly MonochromeIconName AlignLeft = new(nameof(AlignLeft));
    public static readonly MonochromeIconName AlignRight = new(nameof(AlignRight));
    public static readonly MonochromeIconName AlignTop = new(nameof(AlignTop));
    public static readonly MonochromeIconName AlignTopByLowestElement = new(nameof(AlignTopByLowestElement));
    public static readonly MonochromeIconName AllPredecessors = new(nameof(AllPredecessors));
    public static readonly MonochromeIconName AllPredecessorsAndSuccessors = new(nameof(AllPredecessorsAndSuccessors));
    public static readonly MonochromeIconName AllSuccessors = new(nameof(AllSuccessors));
    public static readonly MonochromeIconName ArrowNavigationLightDown = new(nameof(ArrowNavigationLightDown));
    public static readonly MonochromeIconName ArrowNavigationLightLeft = new(nameof(ArrowNavigationLightLeft));
    public static readonly MonochromeIconName ArrowNavigationLightRight = new(nameof(ArrowNavigationLightRight));
    public static readonly MonochromeIconName ArrowNavigationLightUp = new(nameof(ArrowNavigationLightUp));
    public static readonly MonochromeIconName Attached = new(nameof(Attached));
    public static readonly MonochromeIconName BringForward = new(nameof(BringForward));
    public static readonly MonochromeIconName BugLight = new(nameof(BugLight));
    public static readonly MonochromeIconName BugSolid = new(nameof(BugSolid));
    public static readonly MonochromeIconName CalendarLight = new(nameof(CalendarLight));
    public static readonly MonochromeIconName CalendarSolid = new(nameof(CalendarSolid));
    public static readonly MonochromeIconName Check = new(nameof(Check));
    public static readonly MonochromeIconName CheckCircledLight = new(nameof(CheckCircledLight));
    public static readonly MonochromeIconName Chevron = new(nameof(Chevron));
    public static readonly MonochromeIconName Clear = new(nameof(Clear));
    public static readonly MonochromeIconName CloseCircleSolid = new(nameof(CloseCircleSolid));
    public static readonly MonochromeIconName CloseMedium = new(nameof(CloseMedium));
    public static readonly MonochromeIconName CloseSlim = new(nameof(CloseSlim));
    public static readonly MonochromeIconName CloudSolidConnection = new(nameof(CloudSolidConnection));
    public static readonly MonochromeIconName Cluster1 = new(nameof(Cluster1));
    public static readonly MonochromeIconName Cluster2 = new(nameof(Cluster2));
    public static readonly MonochromeIconName CollapseAll = new(nameof(CollapseAll));
    public static readonly MonochromeIconName ColumnChooserEditor = new(nameof(ColumnChooserEditor));
    public static readonly MonochromeIconName ColumnChooserMenu = new(nameof(ColumnChooserMenu));
    public static readonly MonochromeIconName Connectivity = new(nameof(Connectivity));
    public static readonly MonochromeIconName ConnectorAddToContainer = new(nameof(ConnectorAddToContainer));
    public static readonly MonochromeIconName ConnectorCancelPublication = new(nameof(ConnectorCancelPublication));
    public static readonly MonochromeIconName ConnectorDraggingConnectorIn = new(nameof(ConnectorDraggingConnectorIn));
    public static readonly MonochromeIconName ConnectorDraggingConnectorOut = new(nameof(ConnectorDraggingConnectorOut));
    public static readonly MonochromeIconName ConnectorPublish = new(nameof(ConnectorPublish));
    public static readonly MonochromeIconName ConnectorRemoveFromContainer = new(nameof(ConnectorRemoveFromContainer));
    public static readonly MonochromeIconName Container = new(nameof(Container));
    public static readonly MonochromeIconName ContainerAdd = new(nameof(ContainerAdd));
    public static readonly MonochromeIconName ContainerDissolveLight = new(nameof(ContainerDissolveLight));
    public static readonly MonochromeIconName ContainerDissolveSolid = new(nameof(ContainerDissolveSolid));
    public static readonly MonochromeIconName ContainerLockedAction = new(nameof(ContainerLockedAction));
    public static readonly MonochromeIconName ContainerLockedUser = new(nameof(ContainerLockedUser));
    public static readonly MonochromeIconName DatabaseServer = new(nameof(DatabaseServer));
    public static readonly MonochromeIconName DataflowJumpInto = new(nameof(DataflowJumpInto));
    public static readonly MonochromeIconName DataflowLight = new(nameof(DataflowLight));
    public static readonly MonochromeIconName DataflowSolid = new(nameof(DataflowSolid));
    public static readonly MonochromeIconName DataSwitch = new(nameof(DataSwitch));
    public static readonly MonochromeIconName Delete = new(nameof(Delete));
    public static readonly MonochromeIconName DistributeHorizontally = new(nameof(DistributeHorizontally));
    public static readonly MonochromeIconName DistributeVertically = new(nameof(DistributeVertically));
    public static readonly MonochromeIconName DummyIcon = new(nameof(DummyIcon));
    public static readonly MonochromeIconName Duplicate = new(nameof(Duplicate));
    public static readonly MonochromeIconName Edit = new(nameof(Edit));
    public static readonly MonochromeIconName EditHost = new(nameof(EditHost));
    public static readonly MonochromeIconName Email = new(nameof(Email));
    [Obsolete("Use " + nameof(ErrorSolid) + " instead")]
    public static readonly MonochromeIconName ErrorFull = new(nameof(ErrorFull));
    public static readonly MonochromeIconName ErrorLight = new(nameof(ErrorLight));
    public static readonly MonochromeIconName ErrorSolid = new(nameof(ErrorSolid));
    public static readonly MonochromeIconName Exit = new(nameof(Exit));
    public static readonly MonochromeIconName ExpandAll = new(nameof(ExpandAll));
    public static readonly MonochromeIconName ExpanderLightDown = new(nameof(ExpanderLightDown));
    public static readonly MonochromeIconName ExpanderLightLeft = new(nameof(ExpanderLightLeft));
    public static readonly MonochromeIconName ExpanderLightRight = new(nameof(ExpanderLightRight));
    public static readonly MonochromeIconName ExpanderLightTop = new(nameof(ExpanderLightTop));
    public static readonly MonochromeIconName Export = new(nameof(Export));
    public static readonly MonochromeIconName ExternalLink = new(nameof(ExternalLink));
    public static readonly MonochromeIconName FavoriteLightDefault = new(nameof(FavoriteLightDefault));
    public static readonly MonochromeIconName FavoriteSolidDefault = new(nameof(FavoriteSolidDefault));
    public static readonly MonochromeIconName FilterLight = new(nameof(FilterLight));
    public static readonly MonochromeIconName FilterSolid = new(nameof(FilterSolid));
    public static readonly MonochromeIconName FilterSolidClose = new(nameof(FilterSolidClose));
    public static readonly MonochromeIconName FilterSolidInput = new(nameof(FilterSolidInput));
    public static readonly MonochromeIconName FilterSolidOutput = new(nameof(FilterSolidOutput));
    public static readonly MonochromeIconName Folder = new(nameof(Folder));
    public static readonly MonochromeIconName FullSizeExitLight = new(nameof(FullSizeExitLight));
    public static readonly MonochromeIconName FullSizeLight = new(nameof(FullSizeLight));
    public static readonly MonochromeIconName GearLight = new(nameof(GearLight));
    public static readonly MonochromeIconName GearSolid = new(nameof(GearSolid));
    public static readonly MonochromeIconName GeneralMenu = new(nameof(GeneralMenu));
    public static readonly MonochromeIconName GroupByCategory = new(nameof(GroupByCategory));
    public static readonly MonochromeIconName HamburgerMenu = new(nameof(HamburgerMenu));
    public static readonly MonochromeIconName HelpLight = new(nameof(HelpLight));
    public static readonly MonochromeIconName HelpSolid = new(nameof(HelpSolid));
    public static readonly MonochromeIconName Hide = new(nameof(Hide));
    public static readonly MonochromeIconName HomeLight = new(nameof(HomeLight));
    public static readonly MonochromeIconName HomeSolid = new(nameof(HomeSolid));
    public static readonly MonochromeIconName Import = new(nameof(Import));
    public static readonly MonochromeIconName InfoLight = new(nameof(InfoLight));
    public static readonly MonochromeIconName InfoOutlined = new(nameof(InfoOutlined));
    public static readonly MonochromeIconName InfoSolid = new(nameof(InfoSolid));
    public static readonly MonochromeIconName InstallPendingLight = new(nameof(InstallPendingLight));
    public static readonly MonochromeIconName Instructions = new(nameof(Instructions));
    public static readonly MonochromeIconName Invert = new(nameof(Invert));
    public static readonly MonochromeIconName Json = new(nameof(Json));
    public static readonly MonochromeIconName JsonField = new(nameof(JsonField));
    public static readonly MonochromeIconName JsonFieldIn = new(nameof(JsonFieldIn));
    public static readonly MonochromeIconName JsonFieldOut = new(nameof(JsonFieldOut));
    public static readonly MonochromeIconName JsonIn = new(nameof(JsonIn));
    public static readonly MonochromeIconName JsonOut = new(nameof(JsonOut));
    public static readonly MonochromeIconName KebabMenu = new(nameof(KebabMenu));
    public static readonly MonochromeIconName KeyLight = new(nameof(KeyLight));
    public static readonly MonochromeIconName KeySolid = new(nameof(KeySolid));
    public static readonly MonochromeIconName Keyboard = new(nameof(Keyboard));
    public static readonly MonochromeIconName KeychainLight = new(nameof(KeychainLight));
    public static readonly MonochromeIconName KeychainSolid = new(nameof(KeychainSolid));
    public static readonly MonochromeIconName Language = new(nameof(Language));
    public static readonly MonochromeIconName Library = new(nameof(Library));
    public static readonly MonochromeIconName Local = new(nameof(Local));
    public static readonly MonochromeIconName Lock = new(nameof(Lock));
    public static readonly MonochromeIconName LockActive = new(nameof(LockActive));
    public static readonly MonochromeIconName LockTextLabelsLight = new(nameof(LockTextLabelsLight));
    public static readonly MonochromeIconName LockTextLabelsSolid = new(nameof(LockTextLabelsSolid));
    public static readonly MonochromeIconName MinimapLight = new(nameof(MinimapLight));
    public static readonly MonochromeIconName MinusSlim = new(nameof(MinusSlim));
    public static readonly MonochromeIconName MoveDown = new(nameof(MoveDown));
    public static readonly MonochromeIconName MoveLeft = new(nameof(MoveLeft));
    public static readonly MonochromeIconName MoveRight = new(nameof(MoveRight));
    public static readonly MonochromeIconName MoveToNewContainer = new(nameof(MoveToNewContainer));
    public static readonly MonochromeIconName MoveUp = new(nameof(MoveUp));
    public static readonly MonochromeIconName NavigateLight = new(nameof(NavigateLight));
    public static readonly MonochromeIconName NavigateSolid = new(nameof(NavigateSolid));
    public static readonly MonochromeIconName NetworkTopology = new(nameof(NetworkTopology));
    public static readonly MonochromeIconName New = new(nameof(New));
    public static readonly MonochromeIconName NewInWizard = new(nameof(NewInWizard));
    public static readonly MonochromeIconName OfflineLight = new(nameof(OfflineLight));
    public static readonly MonochromeIconName Onboarding = new(nameof(Onboarding));
    public static readonly MonochromeIconName OnOff = new(nameof(OnOff));
    public static readonly MonochromeIconName Open = new(nameof(Open));
    public static readonly MonochromeIconName OpenInNewWindow = new(nameof(OpenInNewWindow));
    public static readonly MonochromeIconName Paste = new(nameof(Paste));
    public static readonly MonochromeIconName PermissionNone = new(nameof(PermissionNone));
    public static readonly MonochromeIconName PermissionViewAndEdit = new(nameof(PermissionViewAndEdit));
    public static readonly MonochromeIconName PermissionViewOnly = new(nameof(PermissionViewOnly));
    public static readonly MonochromeIconName PlusSlim = new(nameof(PlusSlim));
    public static readonly MonochromeIconName Predecessor = new(nameof(Predecessor));
    public static readonly MonochromeIconName Properties = new(nameof(Properties));
    public static readonly MonochromeIconName PublishedConnectorDragging = new(nameof(PublishedConnectorDragging));
    public static readonly MonochromeIconName PublishedConnectorFull = new(nameof(PublishedConnectorFull));
    public static readonly MonochromeIconName Redo = new(nameof(Redo));
    public static readonly MonochromeIconName Refresh = new(nameof(Refresh));
    public static readonly MonochromeIconName Reload = new(nameof(Reload));
    public static readonly MonochromeIconName RtmWarning = new(nameof(RtmWarning));
    public static readonly MonochromeIconName SaveOutline = new(nameof(SaveOutline));
    public static readonly MonochromeIconName Search = new(nameof(Search));
    public static readonly MonochromeIconName SearchAndTools = new(nameof(SearchAndTools));
    public static readonly MonochromeIconName SelectAll = new(nameof(SelectAll));
    public static readonly MonochromeIconName SelectAllBlocks = new(nameof(SelectAllBlocks));
    public static readonly MonochromeIconName SelectConnectorsInput = new(nameof(SelectConnectorsInput));
    public static readonly MonochromeIconName SelectConnectorsInputAll = new(nameof(SelectConnectorsInputAll));
    public static readonly MonochromeIconName SelectConnectorsInputAndOutput = new(nameof(SelectConnectorsInputAndOutput));
    public static readonly MonochromeIconName SelectConnectorsInputAndOutputAll = new(nameof(SelectConnectorsInputAndOutputAll));
    public static readonly MonochromeIconName SelectConnectorsOutput = new(nameof(SelectConnectorsOutput));
    public static readonly MonochromeIconName SelectConnectorsOutputAll = new(nameof(SelectConnectorsOutputAll));
    public static readonly MonochromeIconName Selected = new(nameof(Selected));
    public static readonly MonochromeIconName SendBackward = new(nameof(SendBackward));
    public static readonly MonochromeIconName SendLight = new(nameof(SendLight));
    public static readonly MonochromeIconName SendSolid = new(nameof(SendSolid));
    public static readonly MonochromeIconName ServerLight = new(nameof(ServerLight));
    public static readonly MonochromeIconName ServerNetworkLight = new(nameof(ServerNetworkLight));
    public static readonly MonochromeIconName ServerNetworkSolid = new(nameof(ServerNetworkSolid));
    public static readonly MonochromeIconName ServerSolid = new(nameof(ServerSolid));
    public static readonly MonochromeIconName SeveralToBack = new(nameof(SeveralToBack));
    public static readonly MonochromeIconName SeveralToFront = new(nameof(SeveralToFront));
    public static readonly MonochromeIconName Show = new(nameof(Show));
    public static readonly MonochromeIconName SortChildren = new(nameof(SortChildren));
    public static readonly MonochromeIconName SortDefault = new(nameof(SortDefault));
    public static readonly MonochromeIconName SortUncheckAll = new(nameof(SortUncheckAll));
    public static readonly MonochromeIconName Successor = new(nameof(Successor));
    public static readonly MonochromeIconName SuccessorAndPredecessor = new(nameof(SuccessorAndPredecessor));
    public static readonly MonochromeIconName SwitchOff = new(nameof(SwitchOff));
    public static readonly MonochromeIconName SystemMessagesLight = new(nameof(SystemMessagesLight));
    public static readonly MonochromeIconName SystemMessagesSolid = new(nameof(SystemMessagesSolid));
    public static readonly MonochromeIconName SystemSettingsLight = new(nameof(SystemSettingsLight));
    public static readonly MonochromeIconName SystemSettingsSolid = new(nameof(SystemSettingsSolid));
    public static readonly MonochromeIconName Tagging = new(nameof(Tagging));
    public static readonly MonochromeIconName TemplateBadge = new(nameof(TemplateBadge));
    public static readonly MonochromeIconName TemplateEditor = new(nameof(TemplateEditor));
    public static readonly MonochromeIconName TemplateManagement = new(nameof(TemplateManagement));
    public static readonly MonochromeIconName TestTubeSolid = new(nameof(TestTubeSolid));
    public static readonly MonochromeIconName ThisWeek = new(nameof(ThisWeek));
    public static readonly MonochromeIconName TimeOutLight = new(nameof(TimeOutLight));
    public static readonly MonochromeIconName Timer = new(nameof(Timer));
    public static readonly MonochromeIconName Today = new(nameof(Today));
    public static readonly MonochromeIconName TodayLight = new(nameof(TodayLight));
    public static readonly MonochromeIconName TodaySolid = new(nameof(TodaySolid));
    public static readonly MonochromeIconName Toggle = new(nameof(Toggle));
    public static readonly MonochromeIconName TopologyApplicationLight = new(nameof(TopologyApplicationLight));
    public static readonly MonochromeIconName TopologyEngineLight = new(nameof(TopologyEngineLight));
    public static readonly MonochromeIconName TopologyFolderNetworkLight = new(nameof(TopologyFolderNetworkLight));
    public static readonly MonochromeIconName Undo = new(nameof(Undo));
    public static readonly MonochromeIconName UninstallLight = new(nameof(UninstallLight));
    public static readonly MonochromeIconName UninstallPendingLight = new(nameof(UninstallPendingLight));
    public static readonly MonochromeIconName UpdateAvailableLight = new(nameof(UpdateAvailableLight));
    public static readonly MonochromeIconName UpdateLight = new(nameof(UpdateLight));
    public static readonly MonochromeIconName Urgent = new(nameof(Urgent));
    public static readonly MonochromeIconName UserInterfaceLight = new(nameof(UserInterfaceLight));
    public static readonly MonochromeIconName UserLight = new(nameof(UserLight));
    public static readonly MonochromeIconName UserSolid = new(nameof(UserSolid));
    [Obsolete("Use " + nameof(WarningLight) + " instead")]
    public static readonly MonochromeIconName Warning = new(nameof(Warning));
    [Obsolete("Use " + nameof(WarningSolid) + " instead")]
    public static readonly MonochromeIconName WarningFull = new(nameof(WarningFull));
    public static readonly MonochromeIconName WarningLight = new(nameof(WarningLight));
    public static readonly MonochromeIconName WarningSolid = new(nameof(WarningSolid));
    public static readonly MonochromeIconName Wifi = new(nameof(Wifi));
    public static readonly MonochromeIconName WifiOff = new(nameof(WifiOff));
    public static readonly MonochromeIconName Wizard = new(nameof(Wizard));
    public static readonly MonochromeIconName Zoom100 = new(nameof(Zoom100));
    public static readonly MonochromeIconName ZoomToFit = new(nameof(ZoomToFit));
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    private readonly string _name;

    internal MonochromeIconName(string name)
        => _name = name;

    /// <inheritdoc/>
    public static MonochromeIconName GetDefaultValue()
        => AddUser;

    /// <inheritdoc/>
    public string GetName()
        => _name;

    /// <inheritdoc cref="GetName"/>
    public override string ToString()
        => GetName();
}
