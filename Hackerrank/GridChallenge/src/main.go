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

func sort(s string) string {
	return s
}

func main() {

}
