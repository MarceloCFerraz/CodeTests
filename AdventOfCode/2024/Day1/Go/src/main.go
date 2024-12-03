package main

import (
	"fmt"
	"io"
	"log"
	"math"
	"os"
	"sort"
	"strconv"
	"strings"
)

func ReadFile(name string) ([]byte, error) {
	response := []byte{}
	var file *os.File
	var err error

	cwd, err := os.Getwd()

	if err != nil {
		return response, fmt.Errorf("error getting current working directory: %s", err)
	}

	count := strings.Count(cwd, "/src")

	if count > 1 { // hack to run with vscode's debugger (remove last 'src' from cwd)
		ind := strings.LastIndex(cwd, "src")

		cwd = cwd[:ind]
		file, err = os.Open(cwd + name)
	} else {
		file, err = os.Open(cwd + "/" + name)
	}

	if err != nil {
		return response, fmt.Errorf("error opening file: %s", err)
	}

	response, err = io.ReadAll(file)

	if err != nil {
		return response, fmt.Errorf("error Reading file data: %s", err)
	}

	return response, nil
}

func ReadInput(fileName string) ([]string, error) {
	fileData, err := ReadFile(fileName)
	input := make([]string, 0, len(fileData))

	if err != nil {
		return input, fmt.Errorf("error reading input file '%s': %s", fileName, err)
	}

	input = strings.Split(string(fileData), "\n")

	return input, err
}

func GetListsFromInput(input []string) ([]int64, []int64, error) {
	leftList := make([]int64, 0, len(input))
	rightList := make([]int64, 0, len(input))

	for _, item := range input {
		if strings.Trim(item, " ") == "" {
			continue
		}
		items := strings.Fields(item)

		if len(items) == 1 {
			return leftList, rightList, fmt.Errorf("couldn't split item %s. Result: %s", item, items)
		}

		num1, err := strconv.ParseInt(items[0], 10, 0)

		if err != nil {
			return leftList, rightList, err
		}

		num2, err := strconv.ParseInt(items[1], 10, 0)

		if err != nil {
			return leftList, rightList, err
		}

		leftList = append(leftList, num1)
		rightList = append(rightList, num2)
	}

	return leftList, rightList, nil
}

func Abs(dif int64) uint64 {
	r := uint64(math.Abs(float64(dif)))
	return r
}

func main() {
	input, err := ReadInput("input.txt")

	if err != nil {
		log.Fatalf("ERROR: %s", err)
	}

	leftList, rightList, err := GetListsFromInput(input)

	if err != nil {
		log.Fatalf("ERROR: %s", err)
	}

	if len(leftList) != len(rightList) {
		log.Fatalf("ERROR: list 1 has len %d and list 2 %d", len(leftList), len(rightList))
	}

	sort.Slice(leftList, func(x, y int) bool {
		return leftList[x] < leftList[y]
	})

	sort.Slice(rightList, func(x, y int) bool {
		return rightList[x] < rightList[y]
	})

	var similarity int64 = 0

	for i := range leftList {
		left := leftList[i]

		for j := range rightList {
			right := rightList[j]

			if right == left {
				similarity += left
			}
		}
	}

	log.Printf("Similarity = %d", similarity)
	// similarity += left * frequence on right

}
