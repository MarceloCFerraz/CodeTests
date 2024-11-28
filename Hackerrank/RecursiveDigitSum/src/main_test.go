package main

import "testing"

func TestSuperDigit(t *testing.T) {
	num := "9875"
	var k int32 = 4

	res := SuperDigit(num, k)
	var expected int32 = 8
	// superDigit(p) = superDigit(9875 * 4)
	// 	9+8+7+5+9+8+7+5+9+8+7+5+9+8+7+5 = 116
	// superDigit(p) = superDigit(116)
	// 	1+1+6 = 8
	// superDigit(p) = superDigit(8)

	if res != expected {
		t.Errorf("Something went wrong. Was expecting %d but got %d instead", expected, res)
	}
}
