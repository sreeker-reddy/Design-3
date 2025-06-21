/*
  Time complexity: O(1) Amortized
  Space complexity: O(n)

  Code ran successfully on Leetcode: Yes

*/

public class LRUCache {
    public class Cache{
        public int cacheKey;
        public int cacheValue;

        public Cache(int key, int value)
        {
            cacheKey = key;
            cacheValue = value;
        }
    }

    int capacity;
    Dictionary<int,LinkedListNode<Cache>> dict;
    LinkedList<Cache> list;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        dict = new();
        list = new();
    }
    
    public int Get(int key) {
        if(dict.ContainsKey(key))
        {
            var node = dict[key];
            list.Remove(node);
            list.AddFirst(node);

            return node.Value.cacheValue;
        }
        else
        {
            return -1;
        }
    }
    
    public void Put(int key, int value) {
        if(dict.ContainsKey(key))
        {
            var node = dict[key];
            list.Remove(node);
            node.Value.cacheValue = value;
            list.AddFirst(node);

            dict[key] = node;
        }
        else
        {
            var cacheNode = new Cache(key,value);
            var llNode = new LinkedListNode<Cache>(cacheNode);

            list.AddFirst(llNode);
            dict.Add(key,llNode);

            if(dict.Count>capacity)
            {
                var node = list.Last;
                dict.Remove(node.Value.cacheKey);
                list.Remove(node);
            }
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
