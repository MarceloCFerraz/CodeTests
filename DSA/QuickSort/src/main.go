package main

func QuickSort(arr []int32) []int32 {
	if len(arr) <= 1 {
		return arr
	}

	pivot := arr[0]

	left := []int32{}
	right := []int32{}

	for _, v := range arr {
		if v < pivot {
			left = append(left, v)
			continue
		}

		if v > pivot {
			right = append(right, v)
		}
	}

	return append(append(QuickSort(left), pivot), QuickSort(right)...)
}

func main() {
}
