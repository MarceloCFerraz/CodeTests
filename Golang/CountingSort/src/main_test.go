package main

import (
	"testing"
)

func TestCountingSort(t *testing.T) {
	arr := []int32{5, 1, 3, 9, 7}
	ea := []int32{1, 3, 5, 7, 9}
	eca := []int32{0, 1, 0, 1, 0, 1, 0, 1, 0, 1}

	aa, aca := CountingSort(arr)

	// asserting
	for i := range aa {
		if ea[i] != aa[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", ea, aa)
		}
	}
	
	for i := range aca {
		if eca[i] != aca[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", eca, aca)
		}
	}

	t.Logf("Sorting worked! Sorted: %d, Counting Array: %d\n", aa, aca)
}
