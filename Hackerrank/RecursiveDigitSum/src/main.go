package main

import (
	"strconv"
)

func SuperDigit(n string, k int32) int32 {
	sum := sumStringDigits(n) * uint64(k)

	return reduceToSingleDigit(sum)
}

func sumStringDigits(n string) uint64 {
	var sum uint64 = 0
	for _, d := range n {
		digit, _ := strconv.Atoi(string(d))
		sum += uint64(digit)
	}

	return sum
}

func reduceToSingleDigit(sum uint64) int32{
	if sum < 10 {
		return int32(sum)
	}

	return reduceToSingleDigit(sumDigits(sum))
}

func sumDigits(n uint64) uint64 {
	var sum uint64 = 0
	for n > 0 {
		sum += n % 10
		n /= 10
	}

	return sum
}

func main() {}
