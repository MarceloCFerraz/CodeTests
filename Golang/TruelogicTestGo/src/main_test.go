package main

import (
	"testing"
)

func TestInvert2nMatrix(t *testing.T) {
	n := 1
	matrix := make([][]int32, n*2)
	matrix[0] = []int32{30, 40}
	matrix[1] = []int32{0, 70}

	result := Invert2nMatrix(matrix)

	var expected int32 = 70

	if result != expected {
		t.Errorf("Invert2nMatrix should return %d when matrix is %d", expected, matrix)
	}
}
