#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

;common things to spam in karuta chat

^j::
Send, :tickets: Selling tickets, 18 gems each :gem:
return

^d::
Send, :droplet: Selling droplets, 34 gems each :gem:
return

^n::
Send, :droplet: Buying droplets, 35 gems each :gem:
return

^.::
Send, :droplet: Buying droplets, 2 tickets each :tickets:
return

^h::
Send, :tickets: Buying tickets, 16 gems each :gem:
return

^y::
Send, +{Enter}{Space}      can do bulk
return

^m::
Send, :sparkles: Buying mint dust, 5:1 :tickets:
return

^l::
Send, :sparkles: Buying excellent dust, 10:1 :tickets:
return

^;::
Send, +{Enter}{Space}      can buy a lot
return