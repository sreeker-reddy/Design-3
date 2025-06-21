/*
  Time complexity: O(1) Amortized
  Space complexity:  O(n)

  Code ran successfully on Leetcode: Yes
*/

/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    Stack<IEnumerator<NestedInteger>> stack;
    NestedInteger nextElement;

    public NestedIterator(IList<NestedInteger> nestedList) {
        stack = new();
        stack.Push(nestedList.GetEnumerator());
    }

    public bool HasNext() {
        while(stack.Count>0)
        {
            var next = stack.Peek();
            if(!next.MoveNext())
            {
                stack.Pop();
            }
            else
            {
                var temp = stack.Peek().Current;
                if(temp.IsInteger())
                {
                    nextElement = temp;
                    return true;
                }
                else
                {
                    stack.Push(temp.GetList().GetEnumerator());
                }
            }
        }
        return false;
    }

    public int Next() {
        return nextElement.GetInteger();
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
