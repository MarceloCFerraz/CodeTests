def main():
    for i in range(100_000_000):
        # print(i)

        if i % 10_000_000 == 0:
            print(i)


def with_list_comprehension():
    print([i for i in range(100_000_000) if i % 10_000_000 == 0])


if __name__ == "__main__":
    # main()
    with_list_comprehension()
