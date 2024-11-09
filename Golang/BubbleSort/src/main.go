package main

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
}
