import {Container} from '../../../models';

export interface Flowchart extends Container {
  start: string;
  connections: Array<Connection>;
}

export interface Connection {
  source: string;
  target: string;
  sourcePort: string;
  targetPort: string;
}

export interface WorkflowNavigationItem {
  activityId: string;
  portName?: string;
  index: number;
}
