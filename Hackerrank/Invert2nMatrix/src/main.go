package main

import "log"

func Invert2nMatrix(matrix [][]int32) int32 {
	n := len(matrix) / 2
	log.Printf("n : %d", n)
	var sum int32 = 0

	for i := range n {
		for j := range n {
			upLeft := matrix[i][j]
			upRight := matrix[i][2*n-j-1]
			btLeft := matrix[2*n-i-1][j]
			btRight := matrix[2*n-i-1][2*n-j-1]

			sum += max(upLeft, upRight, btLeft, btRight)
		}
	}

	return sum
}

func max(nums ...int32) int32 {
	max := nums[0]

	for _, num := range nums {
		if num > max {
			max = num
		}
	}

	return max
}

func main() {

}
