package main

import (
	"fmt"
	"io"
	"log"
	"math"
	"os"
	"regexp"
	"strconv"
	"strings"
	"time"
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

func GetReportsFromInput(input []string) ([][]int64, error) {
	reports := make([][]int64, 0, len(input))

	for _, line := range input {
		// log.Println(line)

		if strings.Trim(line, " ") == "" {
			continue
		}

		items := strings.Fields(line)

		if len(items) == 1 {
			return reports, fmt.Errorf("couldn't split item %s. Result: %s", line, items)
		}

		levels := make([]int64, 0, len(items))

		for _, item := range items {
			level, err := strconv.ParseInt(item, 10, 0)

			if err != nil {
				return reports, err
			}

			levels = append(levels, level)
		}

		// log.Printf("%d\n\n", levels)
		reports = append(reports, levels)
	}

	return reports, nil
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

	start := time.Now()

	expr := `mul\([0-9]{1,3},[0-9]{1,3}\)`
	regex, err := regexp.Compile(expr)

	if err != nil {
		log.Fatalf("ERROR: couldn't compile regex '%s': %s", expr, err)
	}

	muls := []string{}
	for i, line := range input {
		if strings.Trim(line, " ") == "" {
			continue
		}

		matches := regex.FindAll([]byte(line), -1)

		if matches == nil {
			log.Printf("No valid mul found on the line %d", i)
		}

		for _, match := range matches {
			filtered := string(match)
			muls = append(muls, filtered)

			fmt.Println(filtered)
		}
		fmt.Println()
	}

	// reports, err := GetReportsFromInput(input)

	// if err != nil {
	// 	log.Fatalf("ERROR: %s", err)
	// }
	log.Printf("%d muls. Processing time: %s", len(muls), time.Now().Sub(start))
}
