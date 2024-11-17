use std::cmp::Ordering;
use std::io;

use rand::Rng;

const MIN: u32 = 1;
const MAX: u32 = 100;

fn main() {
    let secret = rand::thread_rng().gen_range(MIN..=MAX);
    let mut counter = 0;

    println!("Let's play a guessing game!");
    println!("Type a number from {MIN} to {MAX}");

    loop {
        counter += 1;

        let mut guess = String::new();

        io::stdin()
            .read_line(&mut guess)
            .unwrap_or_else(|_| panic!("Failed to read line"));

        let guess: u32 = match guess.trim().parse() {
            Ok(num) => num,
            Err(_) => {
                println!("Please type a valid number");
                continue;
            }
        };

        if guess < MIN || guess > MAX {
            println!("Please enter a number between {} and {}", MIN, MAX);
            continue;
        }

        match guess.cmp(&secret) {
            Ordering::Less => println!("Too small. Try again: "),
            Ordering::Greater => println!("Too big. Try again: "),
            Ordering::Equal => {
                println!("You won!");
                break;
            }
        }
    }
    println!("You took {} rounds to win!", counter)
}
