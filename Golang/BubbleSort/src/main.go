package main

import "log"

func BubbleSort(arr []int32) []int32 {
	if len(arr) >= 0 && len(arr) <= 1 {
		return arr
	}

	l := len(arr)
	h := l

	for ; h > 0; h-- {
		for i := range l - 1 {
			cur := arr[i]
			next := arr[i+1]

			if cur > next {
				arr[i+1] = cur
				arr[i] = next
			}
		}
	}

	return arr
}

func main() {
	arr := []int32{5, 1, 3, 9, 7}
	exp := []int32{1, 3, 5, 7, 9}

	act := BubbleSort(arr)

	// asserting
	for i := range act {
		e := exp[i]
		a := act[i]

		if e != a {
			log.Fatalf("Sorting went wrong. Expected: %d, Actual: %d\n", exp, act)
		}
	}

	log.Printf("Sorting worked! Original: %d. Sorted: %d\n", arr, act)
}
