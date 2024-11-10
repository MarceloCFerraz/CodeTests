package main

func SelectionSort(arr []int32) []int32 {
	for i := range arr {
		min := arr[i]
		var nI int

		for j := i + 1; j < len(arr); j++ {
			if j == i+1 || arr[j] < arr[nI] {
				nI = j
			}

			if j+1 == len(arr) && arr[nI] < min {
				arr[i] = arr[nI]
				arr[nI] = min
			}
		}
	}

	return arr
}

func main() {}
