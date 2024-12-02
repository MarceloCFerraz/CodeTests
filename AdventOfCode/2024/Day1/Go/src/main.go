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

	if count > 1 { // hack to run with vscode debugger
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
	list1 := make([]int64, 0, len(input))
	list2 := make([]int64, 0, len(input))

	for _, item := range input {
		if strings.Trim(item, " ") == "" {
			continue
		}
		items := strings.Fields(item)

		if len(items) == 1 {
			return list1, list2, fmt.Errorf("couldn't split item %s. Result: %s", item, items)
		}

		num1, err := strconv.ParseInt(items[0], 10, 0)

		if err != nil {
			return list1, list2, err
		}

		num2, err := strconv.ParseInt(items[1], 10, 0)

		if err != nil {
			return list1, list2, err
		}

		list1 = append(list1, num1)
		list2 = append(list2, num2)
	}

	return list1, list2, nil
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

	list1, list2, err := GetListsFromInput(input)

	if err != nil {
		log.Fatalf("ERROR: %s", err)
	}

	if len(list1) != len(list2) {
		log.Fatalf("ERROR: list 1 has len %d and list 2 %d", len(list1), len(list2))
	}

	sort.Slice(list1, func(x, y int) bool {
		return list1[x] < list1[y]
	})

	sort.Slice(list2, func(x, y int) bool {
		return list2[x] < list2[y]
	})

	var difsSum uint64 = 0

	for i := range list1 {
		item1 := list1[i]
		item2 := list2[i]

		dif := item1 - item2
		absDif := Abs(dif)

		difsSum += absDif
	}

	log.Printf("Total distance between lists: %d", difsSum)
}
