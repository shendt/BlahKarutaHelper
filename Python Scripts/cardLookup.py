import pyperclip
#import pyautogui

#returns the next card code based on a given card code
def next_card_code(card_code):
    #the characters used in karuta card codes
    characters_string="0123456789bcdfghjklmnpqrstvwxz"
    last_char = card_code[-1]
    if (last_char == 'z'):
        if (len(card_code) <= 1):
            return "00"
        return next_card_code(card_code[0: -1]) + '0'
    last_char_index = characters_string.find(card_code[-1])
    next_char = characters_string[last_char_index + 1]
    return card_code[0: -1] + next_char

#returns the next search command to use given a search command
def next_search_command(search_command):
    search_command_list=["kci", "kwi", "kv"]
    if (search_command == "kv"):
        return "kci"
    search_command_index = search_command_list.index(search_command)
    return search_command_list[search_command_index + 1]

# this script will create a new card lookup command based on a given card lookup command and save it to your clipboard. 
# make sure you have a valid card lookup command using kv, kwi or kci copied to your clipboard before running.
start_string = pyperclip.paste()
space_index = start_string.find(' ')
next_search_command = next_search_command(start_string[0: space_index].lower())
next_card_code = next_card_code(start_string[space_index + 1:].lower())
text = next_search_command + ' ' + next_card_code
pyperclip.copy(text)
