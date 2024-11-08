package main

import (
	"fmt"
	"math"
)

func GetMinCost(numPeople, x, y []int32) int32 {
	var l int32 = 0
	n := GetMax(x...)
	n = GetMax(append(y, n)...)

	totalCosts := make([][]int32, n)
	for i := range n {
		totalCosts[i] = make([]int32, n)
		for j := range n {
			var sum int32 = 0

			for k := range x {
				xc := x[k]
				yc := y[k]
				p := numPeople[k]

				// this is only for debugging. real life: c := p * (abs(xc-i-1) + abs(yc-j-i))
				part := abs(xc-(i+1)) + abs(yc-(j+1))
				c := part * p

				fmt.Printf("|%d - %d| + |%d - %d| = %d * %d = %d\n", xc, i+1, yc, j+1, part, p, c)

				sum += c
			}
			fmt.Printf("Move all to (%d, %d) = %d\n\n", i+1, j+1, sum)

			totalCosts[i][j] = sum
			if l == 0 || l > sum {
				l = sum
			}
		}
	}

	for i := range totalCosts {
		for j := range totalCosts[i] {
			fmt.Printf("%d\t", totalCosts[i][j])
		}

		fmt.Println()
	}

	return l
}

func abs(n int32) int32 {
	return int32(math.Abs(float64(n)))
}

func GetMax(arr ...int32) int32 {
	max := arr[0]

	for i := range arr {
		if arr[i] > max {
			max = arr[i]
		}
	}

	return max
}

func main() {
	numPeople := []int32{1, 1}
	x := []int32{1, 3} // l
	y := []int32{2, 1} // c
	/*
		3	3	5
		3	3	5
		3	3	5
	*/

	r := GetMinCost(numPeople, x, y)

	fmt.Println(r)
}
