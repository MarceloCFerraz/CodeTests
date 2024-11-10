package main

import (
	"bufio"
	"fmt"
	"io"
	"math"
	"os"
	"strconv"
	"strings"
)

func ZigZag(arr []int32) []int32 {
	n := len(arr)
	if n == 0 {
		return arr
	}

	k := (n + 1) / 2

	arr = sortAsc(arr)
	zigZag := make([]int32, n)

	for i := 0; i < k-1; i++ {
		zigZag[i] = arr[i]
	}

	for i := k - 1; i < n; i++ {
		zigZag[i] = arr[(n-1)-abs(k-1-i)]
	}

	return zigZag
}

func abs(v int) int {
	return int(math.Abs(float64(v)))
}

func sortAsc(arr []int32) []int32 {
	// insertion sort
	for i := 1; i < len(arr); i++ {
		j := i - 1
		v := arr[i]

		for ; j >= 0 && arr[j] > v; j-- {
			arr[j+1] = arr[j]
		}

		arr[j+1] = v
	}

	return arr
}
func main() {
	reader := bufio.NewReaderSize(os.Stdin, 16*1024*1024)

	stdout, err := os.Create(os.Getenv("OUTPUT_PATH"))
	checkError(err)

	defer stdout.Close()

	writer := bufio.NewWriterSize(stdout, 16*1024*1024)

	tTemp, err := strconv.ParseInt(strings.TrimSpace(readLine(reader)), 10, 64)
	checkError(err)

	t := int32(tTemp)
	results := make([][]int32, 0, t)

	var i int32 = 0

	for ; i < t; i++ {
		nTemp, err := strconv.ParseInt(strings.TrimSpace(readLine(reader)), 10, 64)
		checkError(err)
		n := int32(nTemp)

		arrTemp := strings.Split(strings.TrimSpace(readLine(reader)), " ")

		var arr []int32

		for i := 0; i < int(n); i++ {
			arrItemTemp, err := strconv.ParseInt(arrTemp[i], 10, 64)
			checkError(err)
			arrItem := int32(arrItemTemp)
			arr = append(arr, arrItem)
		}

		results = append(results, ZigZag(arr))
	}

	for _, result := range results {
		for i, resultItem := range result {
			if i+1 == len(result) {
				fmt.Fprintf(writer, "%d", resultItem)
			} else {
				fmt.Fprintf(writer, "%d ", resultItem)
			}
		}
		fmt.Fprintln(writer)
	}

	writer.Flush()
}

func readLine(reader *bufio.Reader) string {
	str, _, err := reader.ReadLine()
	if err == io.EOF {
		return ""
	}

	return strings.TrimRight(string(str), "\r\n")
}

func checkError(err error) {
	if err != nil {
		panic(err)
	}
}
