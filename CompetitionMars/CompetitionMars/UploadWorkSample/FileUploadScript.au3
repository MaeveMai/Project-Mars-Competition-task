
WinWait("[CLASS:#32770]","",5)
ControlFocus("打开","", "Edit1")
ControlSetText("打开","", "Edit1", "D:\Coding\IC\Competition Mars\Project-Mars-Competition-task\CompetitionMars\CompetitionMars\UploadWorkSample\sample.txt")
Sleep(1000)
ControlClick("打开","","Button1")
