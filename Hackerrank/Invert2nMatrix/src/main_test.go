package main

import (
	"testing"
)

func TestN1Matrix(t *testing.T) {
	n := 1
	matrix := make([][]int32, n*2)
	matrix[0] = []int32{30, 40}
	matrix[1] = []int32{0, 70}

	result := Invert2nMatrix(matrix)

	var expected int32 = 70

	if result != expected {
		t.Errorf("Test for N = 1 should return %d, but was %d. matrix is %d", expected, result, matrix)
	}
}

func TestN2Matrix(t *testing.T) {
	n := 2
	matrix := make([][]int32, n*2)
	matrix[0] = []int32{81, 4, 85, 65}
	matrix[1] = []int32{7, 79, 15, 34}
	matrix[2] = []int32{20, 56, 75, 29}
	matrix[3] = []int32{100, 87, 35, 98}

	result := Invert2nMatrix(matrix)

	var expected int32 = 100 + 87 + 34 + 79

	if result != expected {
		t.Errorf("Test for N = 2 should return %d, but was %d. matrix is %d", expected, result, matrix)
	}
}

func TestN3Matrix(t *testing.T) {
	n := 3
	matrix := make([][]int32, n*2)
	matrix[0] = []int32{81, 4, 85, 65, 78, 9}
	matrix[1] = []int32{7, 79, 15, 34, 5, 12}
	matrix[2] = []int32{20, 56, 75, 29, 90, 33}
	matrix[3] = []int32{100, 87, 35, 98, 109, 4}
	matrix[4] = []int32{1, 90, 23, 44, 50, 83}
	matrix[5] = []int32{83, 28, 19, 28, 37, 48}

	result := Invert2nMatrix(matrix)

	var expected int32 = 83 + 78 + 85 + 83 + 90 + 44 + 100 + 109 + 98

	if result != expected {
		t.Errorf("Test for N = 3 should return %d, but was %d. matrix is %d", expected, result, matrix)
	}
}
