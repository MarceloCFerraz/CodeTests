code = b'{"clientID":1, "value": 10}'
hx = code.hex()

hex_word = ""
count = 0
i = 0
while i < len(hx):
    hex_word += hx[i]
    count += 1

    if count % 2 == 0:
        print(f"0x{hex_word} ", end="")
        hex_word = ""

    i += 1

print()
