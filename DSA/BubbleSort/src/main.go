package main

func BubbleSort(arr []int32) []int32 {
	if len(arr) >= 0 && len(arr) <= 1 {
		return arr
	}

	l := len(arr)
	h := l - 1

	for ; h > 0; h-- {
		for i := range h {
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
}
