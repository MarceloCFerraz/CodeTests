package main

import "testing"

func TestTowerBreaker(t *testing.T) {
	var n int32 = 100001
	var m int32 = 1

	r := TowerBreakers(n, m)

	var e int32 = 2

	if r != e {
		t.Errorf("P%d won, but should've been P%d", r, e)
	}
}
