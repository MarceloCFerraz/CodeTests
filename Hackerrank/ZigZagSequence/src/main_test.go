package main

import "testing"

func TestZigZag(t *testing.T) {
	a := []int32{2, 3, 5, 1, 4}
	e := []int32{1, 2, 5, 4, 3}
	r := ZigZag(a)

	for i := range r {
		if r[i] != e[i] {
			t.Errorf("Error Sorting. Expected: %d, Actual: %d", e, r)
			return
		}
	}

	t.Logf("ZigZag succeeded. Old: %d, Actual: %d", a, r)
}
