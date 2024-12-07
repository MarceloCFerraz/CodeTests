package main

import (
	"fmt"
	"io"
	"log"
	"math"
	"os"
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

	muls := ManuallyLoadMulsFromInput(input)

	log.Printf("%d muls. Processing time: %s", len(muls), time.Now().Sub(start))
}

func ManuallyLoadMulsFromInput(input []string) []string {
	muls := make([]string, 0)

	for i := range input {
		line := input[i]

		mul := ""
		nums := [2]int{0, 0}
		np := 0
		for j := 0; j < len(line); j++ {
			if j > len(line)-8 {
				break
			}
			c := string(line[j])
			c += ""

			if mul == "" &&
				rune(line[j]) == 'm' &&
				rune(line[j+1]) == 'u' &&
				rune(line[j+2]) == 'l' &&
				rune(line[j+3]) == '(' {
				mul += "mul("
				j += 4
			}

			c = string(line[j])
			if mul != "mul(" {
				continue
			}

			if (!isDigit(rune(line[j])) && nums[np] == 0) ||
				(isDigit(rune(line[j])) && nums[np] >= 1000) ||
				(rune(line[j]) == ')' && nums[np] == 0) || // replicate for np == 1 and for only np == 0
				(rune(line[j]) == ')' && np == 0) || // replicate for np == 1 and for only np == 0
				(rune(line[j]) == ',' && np == 1) {
				mul = ""
				nums[0] = 0
				nums[1] = 0
				np = 0
				continue
			}

			if rune(line[j]) == ',' {
				np += 1
				continue
			}

			if rune(line[j]) == ')' {
				mul += strconv.Itoa(nums[0]) + "," + strconv.Itoa(nums[1]) + ")"
				fmt.Println(mul)
				muls = append(muls, mul)
				mul = ""
				nums[0] = 0
				nums[1] = 0
				np = 0
				continue
			}

			conv, _ := strconv.Atoi(string(line[j]))
			if nums[np] > 0 {
				nums[np] *= 10
				nums[np] += conv
			} else {
				nums[np] = conv
			}
		}
	}

	return muls
}

func isDigit(c rune) bool {
	switch c {
	case '0':
		return true
	case '1':
		return true
	case '2':
		return true
	case '3':
		return true
	case '4':
		return true
	case '5':
		return true
	case '6':
		return true
	case '7':
		return true
	case '8':
		return true
	case '9':
		return true
	default:
		return false
	}
}
