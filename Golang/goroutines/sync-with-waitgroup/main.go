package main

import (
	"fmt"
	"math/rand"
	"sync"
	"time"
)

func main() {
	var msgs = make(chan string)
	const maxT = 5                      // max concurrent jobs
	var limiter = make(chan bool, maxT) // used to limit concurrent processing of up to 5 go routines
	// could be whatever type: int, float, byte, string, ...
	wait := sync.WaitGroup{} // useful to sync multiple concurrent go routines and ensure all of them finalize

	go func(maxT int, m <-chan string, done chan<- bool) {
		for {
			val, open := <-m
			if open {
				fmt.Println("Message: ", val)
			} else {
				done <- true // adds another value to the limitter in this case just to make main thread wait until every line is read.
				// A simpler substitute for waitgroup (this is a single gr, no need to use wg here)
				return // exit the go routine
				// exit gr avoids mem leak, otherwise we could omit this line and let main thread kill everything
			}
		}
	}(maxT, msgs, limiter)

	for i := range maxT + 5 {
		wait.Add(1)
		limiter <- true // increment limiter count. when count gets top max, block until a space is freed
		go func() {     // creating a bunch of messages concurrently
			defer wait.Done()

			// simulate io/cpu intensive operation
			wait := time.Duration(rand.Intn(2000)) * time.Millisecond
			time.Sleep(wait) // random wait times from 0 to 5 full secs

			msgs <- fmt.Sprintf("%d: waited %d ms", i, wait.Milliseconds())
			<-limiter // free space in limiter queue
		}()
	}
	wait.Wait() // wait all concurrent wait groups to finish with .Done
	close(msgs) // signal that no more messages will be enqueued. Makes `val, open := <-m` possible

	<-limiter // wait for reader go routine finish before quitting

}
