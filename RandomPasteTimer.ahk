#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;paste and enter randomly every once in a while.
;The interval between each paste will change randomly every time

#Persistent
SetTimer, Paste, 10000
Return

Paste:
Random, sleep, 300000, 600000
SetTimer, Paste, %sleep%
Send, ^v{enter}
Return