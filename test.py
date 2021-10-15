from uuid import uuid4


def setup(context, client1, client2):
    context['session_id'] = uuid4()
    print('Test setup: %s' % context['session_id'])


def test(context, client1, client2):
    print("Hello 2 clients: %s" % context['session_id'])
    client1.Add(3, 4)
    client2.Add(3, 4)
    client1.Call('test_method', [42, 'test arg'], dict(key1='value 1', key42=42))


def teardown(context, client1, client2):
    print('Test teardown: %s' % context['session_id'])
