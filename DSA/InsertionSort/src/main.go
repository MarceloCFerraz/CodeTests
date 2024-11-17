package main

func InsertionSort(arr []int32) []int32 {
	for i := 1; i < len(arr); i++ {
		pin := arr[i]

		// shifting items that are bigger than pin to the right
		j := i - 1
		for ; j >= 0 && arr[j] > pin; j-- {
			arr[j+1] = arr[j]
		}

		// putting pin value on the last item before condition became false
		arr[j+1] = pin
	}

	return arr
}

func main() {}
