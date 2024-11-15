package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
	"strconv"
	"strings"
)

/*
 * Complete the 'towerBreakers' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER n
 *  2. INTEGER m
 */
func TowerBreakers(n int32, m int32) int32 {
	if m == 1 || n%2 == 0 {
		return 2
	}

	return 1

	// below is brute force

	towers := make(map[int32]int32, n)
	var i int32 = 0
	for ; i < n; i++ {
		towers[i] = m
	}

	for j := 0; ; j++ {
		player := (j % 2) + 1

		moved := false

		for i = 0; i < n && !moved; i++ {
			if towers[i] == 1 {
				continue
			}

			towers[i] = 1 // y := towers[i] - 1; towers[i] = towers[i] - y
			moved = true
		}

		if !moved {
			return int32(3 - player) // 3 - 1 = 2; 3 - 2 = 1
		}
	}
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

	for tItr := 0; tItr < int(t); tItr++ {
		firstMultipleInput := strings.Split(strings.TrimSpace(readLine(reader)), " ")

		nTemp, err := strconv.ParseInt(firstMultipleInput[0], 10, 64)
		checkError(err)
		n := int32(nTemp)

		mTemp, err := strconv.ParseInt(firstMultipleInput[1], 10, 64)
		checkError(err)
		m := int32(mTemp)

		result := TowerBreakers(n, m)

		fmt.Fprintf(writer, "%d\n", result)
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
