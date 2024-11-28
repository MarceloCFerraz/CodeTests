package main

import "testing"

func TestGridChallenge3x3(t *testing.T) {
	grid := []string{
		"acb",
		"fed",
		"gih",
	}
	expected := "YES"

	actual := GridChallenge(grid)

	if actual != expected {
		t.Errorf("Code is wrong. Was expecting %s but got %s", expected, actual)
		return
	}
}

func TestGridChallenge4x3(t *testing.T) {
	grid := []string{
		"acb",
		"fed",
		"gih",
		"jkl",
	}
	expected := "YES"

	actual := GridChallenge(grid)

	if actual != expected {
		t.Errorf("Code is wrong. Was expecting %s but got %s", expected, actual)
		return
	}
}
