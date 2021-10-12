def setup(context, client1, client2):
    print('Test setup')
    pass


def test(context, client1, client2):
    print("Hello 2 clients")
    client1.Add(3, 4)
    client2.Add(3, 4)
    assert False, "assertion in testcase"


def teardown(context, client1, client2):
    pass
