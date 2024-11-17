package main

import "testing"

func TestCaesarCypher(t *testing.T) {
	str := "middle-Outz"
	k := 2
	expected := "okffng-Qwvb"

	conv := CaesarCypher(str, k)

	if conv != expected {
		t.Errorf("Cypher failed. Should've been %s but was %s", expected, conv)
	}
}
