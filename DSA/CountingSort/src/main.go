package main

func CountingSort(arr []int32) ([]int32, []int32) {
	if len(arr) <= 1 {
		return arr, nil
	}

	n := getMax(arr)
	ca := make([]int32, n+1) // +1 because range will go from 0 until len - 1, we want to include max value as an index

	// use each element in the original array as index for the auxiliary arr and increment
	// if arr = 5, 1, 3, 9, 7,
	// ca = 0 1 0 1 0 1 0 1 0 1 
	// 9 repeats 1 time on arr, so ca[9] = 1
	for _, v := range arr {
		ca[v] += 1
	}

	// run through the count array and fill the sorted array with indexes if count != 0
	sorted := make([]int32, 0, len(arr))
	for i, count := range ca {
		if count == 0 {
			continue
		}

		for range count {
			sorted = append(sorted, int32(i))
		}
	}

	return sorted, ca
}

func getMax(arr []int32) int32 {
	max := arr[0]

	for i := range arr {
		if arr[i] > max {
			max = arr[i]
		}
	}

	return max
}

func main() {
}
