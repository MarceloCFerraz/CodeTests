package main

import (
	"testing"
)

func TestGetMinCost(t *testing.T) {
	numPeople := []int32{1, 2}
	x := []int32{1, 3} // l
	y := []int32{2, 1} // c
	/*
		|1 - 1| + |2 - 1| = 1 * 2 = 2
		|3 - 1| + |1 - 1| = 2 * 1 = 2
		Move all to (1, 1) = 4

		|1 - 1| + |2 - 2| = 0 * 2 = 0
		|3 - 1| + |1 - 2| = 3 * 1 = 3
		Move all to (1, 2) = 3

		|1 - 1| + |2 - 3| = 1 * 2 = 2
		|3 - 1| + |1 - 3| = 4 * 1 = 4
		Move all to (1, 3) = 6

		|1 - 2| + |2 - 1| = 2 * 2 = 4
		|3 - 2| + |1 - 1| = 1 * 1 = 1
		Move all to (2, 1) = 5

		|1 - 2| + |2 - 2| = 1 * 2 = 2
		|3 - 2| + |1 - 2| = 2 * 1 = 2
		Move all to (2, 2) = 4

		|1 - 2| + |2 - 3| = 2 * 2 = 4
		|3 - 2| + |1 - 3| = 3 * 1 = 3
		Move all to (2, 3) = 7

		|1 - 3| + |2 - 1| = 3 * 2 = 6
		|3 - 3| + |1 - 1| = 0 * 1 = 0
		Move all to (3, 1) = 6

		|1 - 3| + |2 - 2| = 2 * 2 = 4
		|3 - 3| + |1 - 2| = 1 * 1 = 1
		Move all to (3, 2) = 5

		|1 - 3| + |2 - 3| = 3 * 2 = 6
		|3 - 3| + |1 - 3| = 2 * 1 = 2
		Move all to (3, 3) = 8

		4       3       6
		5       4       7
		6       5       8
	*/

	r := GetMinCost(numPeople, x, y)

	var expected int32 = 3

	if r != expected {
		t.Errorf("Function should return %d, but was %d. numPeople: %v, x: %v, y: %v", expected, r, numPeople, x, y)
	}
}
