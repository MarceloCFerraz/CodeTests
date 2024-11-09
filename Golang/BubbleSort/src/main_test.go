package main

import (
	"testing"
)

func TestBubbleSort(t *testing.T) {
	arr := []int32{5, 1, 3, 9, 7}
	ea := []int32{1, 3, 5, 7, 9}

	act := BubbleSort(arr)

	// asserting
	for i := range act {
		if ea[i] != act[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", ea, act)
		}
	}

	t.Logf("Sorting worked! Original: %d. Sorted: %d\n", arr, act)
}
