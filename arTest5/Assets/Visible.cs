using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Visible: MonoBehaviour
{
    ARTrackedObjectManager m_TrackedObjectManager;
    ARTrackedObject m_TrackedObject;

    void OnEnable()
    {
        m_TrackedObjectManager = FindObjectOfType<ARTrackedObjectManager>();
     
        m_TrackedObjectManager.trackedObjectsChanged += OnTrackedObjectsChanged;
    }

    void OnDisable()
    {
        m_TrackedObjectManager.trackedObjectsChanged -= OnTrackedObjectsChanged;
    }

    void OnTrackedObjectsChanged(ARTrackedObjectsChangedEventArgs eventArgs)
    {
        foreach (ARTrackedObject trackedObject in eventArgs.added)
        {
            if (trackedObject.gameObject == gameObject)
            {
                OnBecameVisible();
                m_TrackedObject = trackedObject;
            }
        }

        foreach (ARTrackedObject trackedObject in eventArgs.removed)
        {
            if (trackedObject == m_TrackedObject)
            {
                OnBecameInvisible();
                m_TrackedObject = null;
            }
        }
    }

    void OnBecameVisible()
    {
        Debug.Log("VISIBLEEEEEEEEE");
    }

    void OnBecameInvisible()
    {
        Debug.Log("INVISIBLEEEEEEEEE");
    }
}


