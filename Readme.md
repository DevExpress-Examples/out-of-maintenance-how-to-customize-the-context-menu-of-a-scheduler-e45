<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomContextMenu/Form1.cs) (VB: [Form1.vb](./VB/CustomContextMenu/Form1.vb))
<!-- default file list end -->
# How to customize the context menu of a Scheduler


<p>Problem: </p><p>In my application I need to customize the context menu which is shown every time end-users right-click the Scheduler control. Some items should be hidden, others should be renamed or disabled. Is this possible?</p><p>Solution:</p><p>To change items in a context menu handle the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraSpreadsheetSpreadsheetControl_PopupMenuShowingtopic"><u>SchedulerControl.PopupMenuShowing</u></a> event of a Scheduler, and then use the <a href="http://help.devexpress.com/#WindowsForms/DevExpressXtraSchedulerPopupMenuShowingEventArgs_Menutopic"><u>PopupMenuShowingEventArgs.Menu</u></a> property. This example demonstrates how to customize the SchedulerControl's context menus (in this instance it is the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerMenuItemIdEnumtopic"><u>SchedulerMenuItemId.DefaultMenu</u></a>  which is invoked when clicking the empty time cells). You may fill in the fields of the invoked editing form for the newly created appointment by handling the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_EditAppointmentFormShowingtopic"><u>EditAppointmentFormShowing</u></a> event and checking the result of the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerAppointmentStorageBase_IsNewAppointmenttopic"><u>IsNewAppointment</u></a> method.</p>


<h3>Description</h3>

<p>Starting from the v2010 vol 2, the SchedulerControl.PopupMenuShowing event replaces PreparePopupMenu and  PrepareContextMenu events.</p>

<br/>


