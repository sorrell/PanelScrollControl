# PanelScrollControl
A Winforms Scrollable Panel in the vein of Word 2013.  A scrollable panel that could be used in a Word Addin that provides the feel of the scroll buttons in the:

* Document Recovery Pane
* Navigation Pane
* Probably other panes I haven't yet cared to discover

When you need to scroll with the feel of a native Office pane, this control provides the functionality.  Designed to be used with existing code, simply pass your pane into the control, and check a few settings.
![image](http://i.imgur.com/C2r5nV2.gif)


### Usage
* Build the solution so that you create the DLL.
* Add reference to the DLL in your project
* Either inherit or create this control in your project.
* Set these properties!
```c#
    PanelContainer = MyMainPanel;
    BottomControl = TheBottomMostControlOfMyPanel;
    TopControl = TheTopMostControlOfMyPanel;
    TopHeightMargin = MaybeIHaveAMenustripOrHeaderIWantToAccountFor.Height;
    ScrollSpeed = 1;   // although you can scroll faster!
```
* Override the ToggleButtons method (commented out code works for most situations)
* If you have collapsible/expandable elements at the top/bottom, check out the ToggleButtons modified implementation.