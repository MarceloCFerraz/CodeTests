package main

func CaesarCypher(str string, k int) string {
	converted := make([]rune, 0, len(str))
	k = k % 26

	for _, char := range str {
		// if not a letter
		if (char < 'a' || char > 'z') && (char < 'A' || char > 'Z') {
			converted = append(converted, char)
			continue
		}

		a := 'a'
		if char >= 'A' && char <= 'Z' {
			a = 'A'
		}

		c := a + (char-a+rune(k))%26
		println(c)
		converted = append(converted, c)
	}

	return string(converted)
}

func main() {

}
