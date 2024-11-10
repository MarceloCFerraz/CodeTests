package main

import (
	"testing"
)

func TestSelectionSort(t *testing.T) {
	arr := []int32{5, 1, 3, 1, 9, 0, 7}
	ea := []int32{0, 1, 1, 3, 5, 7, 9}

	act := InsertionSort(arr)

	// asserting
	if len(ea) != len(act) {
		t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", ea, act)
	}

	for i := range act {
		if ea[i] != act[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", ea, act)
		}
	}

	t.Logf("Sorting worked! Original: %d. Sorted: %d\n", arr, act)
}
