import curses

def print_menu(stdscr, selected_row_idx, menu):
    stdscr.clear()
    h, w = stdscr.getmaxyx()

    for idx, row in enumerate(menu):
        x = w//2 - len(row)//2
        y = h//2 - len(menu)//2 + idx
        if idx == selected_row_idx:
            stdscr.attron(curses.color_pair(1))
            stdscr.addstr(y, x, row)
            stdscr.attroff(curses.color_pair(1))
        else:
            stdscr.addstr(y, x, row)
    
    stdscr.refresh()

def main(stdscr):
    # Turn off cursor blinking
    curses.curs_set(0)
    # Color scheme for selected row
    curses.init_pair(1, curses.COLOR_BLACK, curses.COLOR_WHITE)
    
    # Menu options
    menu = ['Option 1', 'Option 2', 'Option 3', 'Exit']
    current_row = 0
    
    print_menu(stdscr, current_row, menu)

    while 1:
        key = stdscr.getch()

        if key == curses.KEY_UP and current_row > 0:
            current_row -= 1
        elif key == curses.KEY_DOWN and current_row < len(menu) - 1:
            current_row += 1
        elif key == curses.KEY_ENTER or key in [10, 13]:
            if current_row == len(menu) - 1:
                break  # Exit the program if "Exit" is selected
            stdscr.addstr(0, 0, f"You selected {menu[current_row]}")
            stdscr.refresh()
            stdscr.getch()

        print_menu(stdscr, current_row, menu)

curses.wrapper(main)