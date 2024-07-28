from python import Python


fn test_using_utils(module_path: String) raises:
    Python.add_to_path(module_path)

    var utils = Python.import_module("utils")

    var env = utils.select_env()
    print(env)

    var org_id = utils.select_org(env)
    print(org_id)


fn test_python_for_loop(module_path: String) raises:
    Python.add_to_path(module_path)

    var for_test = Python.import_module("for_test")

    # for_test.main()
    for_test.with_list_comprehension()


fn test_for_loop():
    for i in range(100_000_000):
        # print(i)

        if i % 10_000_000 == 0:
            print(i)


fn main() raises:
    # print("Hello World!")

    # test_using_utils("../MZScripts/utils")
    test_python_for_loop(".")
    # test_for_loop()
