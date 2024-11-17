package main

import (
	"fmt"
	"sort"
)

func MakeArraysEqual(arr1, arr2 []int32) (int32, error) {
	if len(arr2) != len(arr1)-2 {
		return -1, fmt.Errorf("arr2 must have len(arr1) - 2 items")
	}
	difCount := make(map[int32]int)

	for i := range arr1 {
		for j := range arr2 {
			dif := arr2[j] - arr1[i]
			if _, exist := difCount[dif]; !exist {
				difCount[dif] = 0
			}

			difCount[dif]++
		}
	}

	difs := make([]int32, 0, 1)
	for d, c := range difCount {
		if c%len(arr2) == 0 {
			difs = append(difs, d)
		}
	}

	if len(difs) == 0 {
		return -1, fmt.Errorf("it is not possible to create arr2 from arr1. arr1: %d, arr2: %d", arr1, arr2)
	}

	sort.Slice(difs, func(x, y int) bool {
		return difs[x] < difs[y]
	})

	return difs[0], nil
}

func main() {}
