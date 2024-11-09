package main

func MergeSort(arr []int32) []int32 {
	if len(arr) <= 1 {
		return arr
	}

	mid := len(arr) / 2
	left := MergeSort(arr[:mid])  // 0 - mid (not included)
	right := MergeSort(arr[mid:]) // mid - n (mid included)

	return Merge(left, right)
}

func Merge(left, right []int32) []int32 {
	n := len(left) + len(right)
	l := 0
	r := 0

	u := make([]int32, 0, n)

	// fill u in order by running over left and right simultaneously
	for l < len(left) && r < len(right) {
		if left[l] < right[r] {
			u = append(u, left[l])
			l++
		} else {
			u = append(u, right[r])
			r++
		}
	}

	// one of the two pointers finished,
	// complete with the rest of the other pointer
	if l < len(left) {
		u = append(u, left[l:]...)
	}
	if r < len(right) {
		u = append(u, right[r:]...)
	}

	return u
}

func main() {
}
