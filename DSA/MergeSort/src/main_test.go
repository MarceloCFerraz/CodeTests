package main

import (
	"testing"
)

func TestMergeSort(t *testing.T) {
	arr := []int32{5, 1, 3, 9, 7}
	ea := []int32{1, 3, 5, 7, 9}

	act := MergeSort(arr)

	// asserting
	for i := range act {
		if ea[i] != act[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", ea, act)
		}
	}

	t.Logf("Sorting worked! Original: %d. Sorted: %d\n", arr, act)
}

func TestMerge(t *testing.T) {
	l := []int32{1, 5}
	r := []int32{3, 7}
	e := []int32{1, 3, 5, 7}

	act := Merge(l, r)

	// asserting
	for i := range act {
		if e[i] != act[i] {
			t.Errorf("Sorting went wrong. Expected: %d, Actual: %d\n", e, act)
		}
	}

	t.Logf("Merge worked! Left: %d. Right: %d. Merged: %d\n", l, r, act)
}
