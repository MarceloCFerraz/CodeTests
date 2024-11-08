package main

import (
	"encoding/json"
	"fmt"
	"io"
	"net/http"
)

// the rest of the properties are useless
type Page struct {
	Users []User `json:"data"`
	End   int    `json:"total_pages"`
}

// the rest of the properties are useless
type User struct {
	Username    string `json:"username"`
	Submissions int32    `json:"total_submissions"`
}

func GetUsernames(threshold int32) []string {
	usernames := make([]string, 0)

	page := 1
	for {
		req, err := http.NewRequest(
			"GET",
			fmt.Sprintf("https://url.com/search?page=%d", page),
			nil,
		)
		if err != nil {
			panic(err)
		}

		client := http.Client{}

		resp, err := client.Do(req)
		if err != nil {
			panic(err)
		}

		dt, err := io.ReadAll(resp.Body)
		if err != nil {
			panic(err)
		}
		resp.Body.Close()

		j := Page{}

		err = json.Unmarshal(dt, &j)
		if err != nil {
			panic(err)
		}

		for _, u := range j.Users{
			if u.Submissions > threshold {
				usernames = append(usernames, u.Username)
			}
		}

		done := page > j.End // End page is still readable

		if done {
			break
		}

		page++
	}

	return usernames
}

func main() {
	n := GetUsernames(10)

	fmt.Println(n)
}
