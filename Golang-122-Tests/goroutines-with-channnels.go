package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	// -----------------------------------------------------------------------------------------
	// this piece of code adds values to the unbuffered channel only if there is someone listening
	// otherwise, waits until someone reads the channel and only when a space is available puts a new value
	// when all values were read, send signal to channel 'done' which will signal to main thread that all work was done
	fmt.Println("Unbuffered Channel")

	const max = 3
	var chUnb = make(chan int)
	var done = make(chan bool)

	go func() { // firing a single goroutine to read stuff from unbuffered channel
		for {
			value, open := <-chUnb

			if open {
				time.Sleep(time.Duration(rand.Intn(1000)) * time.Millisecond) // sleep for up to 1s
				fmt.Println("Item:", value)
			} else {
				done <- true
				return
			}
		}
	}()

	for i := 0; i < max+2; i++ {
		fmt.Println("Adding", i, "to unb channel")
		chUnb <- i
	}
	close(chUnb) // send signal that no more values will be inserted

	<-done

	// -----------------------------------------------------------------------------------------
	// this piece of code adds values to the buffered channel independently if there is someone listening
	// values are then read sequentially by workers listening to the channel
	// when all values were read, send signal to channel 'done' which will signal to main thread that all work was done
	fmt.Println("----------------------------------")
	fmt.Println("Buffered Channel")

	var chBuf = make(chan int, max)
	go func() { // firing another goroutine to read stuff from buffered channel
		for {
			value, open := <-chBuf

			if open {
				time.Sleep(time.Duration(rand.Intn(1000)) * time.Millisecond) // sleep for up to 1s
				fmt.Println("Item:", value)
			} else {
				done <- true
				return
			}
		}
	}()

	for i := 0; i < max+2; i++ {
		fmt.Println("Adding", i, "to buf channel")
		chBuf <- i
	}
	close(chBuf) // send signal that no more values will be inserted

	<-done // wait until channel was completely read
}
