package main

const (
	YES R = iota
	NO
)

type R int

func (r R) ToString() string {
	return []string{"YES", "NO"}[r]
}

func GridChallenge(grid []string) string {
	n := len(grid)
	cols := make([]string, len(grid[0]))

	// sort rows
	for i := range n {
		grid[i] = Sort(grid[i])
	}

	// turn columns into rows
	for i := range len(cols) {
		for j := range n {
			cols[i] += string(grid[j][i])
		}
	}

	// check if columns are ordered too
	for i := range len(cols) {
		if !isOrderedAsc(string(cols[i])) {
			return NO.ToString()
		}
	}

	return YES.ToString()
}

func isOrderedAsc(s string) bool {
	for i := 1; i < len(s); i++ {
		if s[i-1] > s[i] {
			return false
		}
	}
	return true
}

func Sort(s string) string {
	// convert string to array of runes and do bubble sort with smallest char always on the beggining
	r := make([]rune, 0, len(s))
	for i := range s {
		r = append(r, rune(s[i]))
	}

	for i := range r {
		smallest := r[i]

		for j := i + 1; j < len(r); j++ {
			if r[j] < smallest {
				smallest = r[j]

				r[j] = r[i]
				r[i] = smallest
			}
		}
	}

	return string(r)
}

func main() {

}
