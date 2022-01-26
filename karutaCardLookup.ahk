#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;if there is a lookup command "kv", "kwi" or "kci" in the clipboard followed by a card code,
;this will copy a new lookup command with the next card code into the clipboard, paste and enter it.
;change the run command to run python wherever you have it installed. Also requires pyperclip module.

^f::
run, C:\ProgramData\Anaconda3\python.exe "%A_WorkingDir%\Python Scripts\cardLookup.py"
sleep, 500
send, ^v{Enter}