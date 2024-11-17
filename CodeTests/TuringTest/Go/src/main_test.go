package main

import "testing"

func TestExtract(t *testing.T) {
	arr1 := []int32{6, 9, 9, 6}
	arr2 := []int32{12, 12}
	var expected int32 = 3 // could be 6, but we want the smallest int possible

	r, e := MakeArraysEqual(arr1, arr2)

	if e != nil {
		t.Errorf("An error has occurred: %s", e)
		return
	}

	if r != expected {
		t.Errorf("Dif should be %d, but was %d", expected, r)
		return
	}
}
